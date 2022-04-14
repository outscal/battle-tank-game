using Adobe.Substance.Input;
using Adobe.Substance.Input.Description;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace Adobe.Substance.Editor
{
    /// <summary>
    /// Cached info for a substance input. Allow drawing UI without having to query description values from the SerializedProperty object.
    /// </summary>
    internal class SubstanceInputCachedInfo
    {
        /// <summary>
        /// Input serialized property.
        /// </summary>
        public SerializedProperty InputProperty { get; }

        /// <summary>
        /// GUIContent for the drawing the input.
        /// </summary>
        public SubstanceInputGUIContent GUIContent { get; }

        public bool IsVisible => _IsVisibleProperty.boolValue;

        private readonly SerializedProperty _IsVisibleProperty;

        public SubstanceInputCachedInfo(SerializedProperty inputProperty, SubstanceInputGUIContent GUIContent)
        {
            this.InputProperty = inputProperty;
            this.GUIContent = GUIContent;
            _IsVisibleProperty = inputProperty.FindPropertyRelative("_isVisible");
        }
    }

    internal class SubstanceInputGroupCachedInfo
    {
        public string Name { get; }

        public List<SubstanceInputCachedInfo> Inputs { get; }

        public bool ShowGroup { get; set; }

        public SubstanceInputGroupCachedInfo(string groupName)
        {
            Name = groupName;
            Inputs = new List<SubstanceInputCachedInfo>();
            ShowGroup = false;
        }
    }

    /// <summary>
    /// Helper class for caching grouping information for inputs so we don't have to query them every UI draw.
    /// </summary>
    internal class GraphInputsGroupingHelper
    {
        /// <summary>
        /// Readonly list with all input groups and their elements info.
        /// </summary>
        public IReadOnlyList<SubstanceInputGroupCachedInfo> InputGroups { get; }

        /// <summary>
        /// Groups with inputs that don't have grouping information.
        /// </summary>
        public SubstanceInputGroupCachedInfo GrouplessInputs { get; }

        public GraphInputsGroupingHelper(List<SubstanceGraph> graphs, SerializedObject targetObject)
        {
            var graphsList = targetObject.FindProperty("Graphs");
            var GUIgroups = new List<SubstanceInputGroupCachedInfo>();

            foreach (var graph in graphs)
            {
                SerializedProperty rootGraph = graphsList.GetArrayElementAtIndex(graph.Index);
                var graphInputs = rootGraph.FindPropertyRelative("Input");

                var groups = graph.Input.Select(a => a.Description.GuiGroup).Distinct();

                foreach (var group in groups)
                {
                    var groupInfo = new SubstanceInputGroupCachedInfo(group);

                    for (int i = 0; i < graph.Input.Count; i++)
                    {
                        var target = graph.Input[i];

                        if (target.Description.GuiGroup == group)
                        {
                            SubstanceInputGUIContent guiContent;

                            if (target.IsNumeric)
                                guiContent = new SubstanceNumericalInputGUIContent(target.Description, target.NumericalDescription);
                            else
                                guiContent = new SubstanceInputGUIContent(target.Description);

                            groupInfo.Inputs.Add(new SubstanceInputCachedInfo(graphInputs.GetArrayElementAtIndex(i), guiContent));
                        }
                    }

                    if (string.IsNullOrEmpty(groupInfo.Name))
                    {
                        if (GrouplessInputs == null)
                            GrouplessInputs = groupInfo;
                        else
                            GrouplessInputs.Inputs.AddRange(groupInfo.Inputs);
                    }
                    else
                    {
                        GUIgroups.Add(groupInfo);
                    }
                }
            }

            InputGroups = GUIgroups;
        }
    }

    internal class GraphOutputAlphaChannelsHelper
    {
        private readonly List<string> _channels;

        public GraphOutputAlphaChannelsHelper(SubstanceGraph graph)
        {
            _channels = new List<string> { "source" };

            foreach (var item in graph.Output.Where(a => a.IsAlphaAssignable).Select(b => b.Description.Label))
                _channels.Add(item);
        }

        public string[] GetAlphaChannels(string label)
        {
            return _channels.Where(a => a != label).ToArray();
        }
    }
}