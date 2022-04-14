using Adobe.Substance.Input;
using Adobe.Substance.Input.Description;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Adobe.Substance.Runtime
{
    public class SubstanceRuntimeMaterial : MonoBehaviour
    {
        [SerializeField]
        private SubstanceMaterialInstanceSO SubstanceMaterial;

        private SubstanceNativeHandler _runtimeHandler;

        public Material DefaulMaterial => SubstanceMaterial.Graphs[0].OutputMaterial;

        private readonly ConcurrentQueue<AsyncRenderResult> _asyncRenderQueue = new ConcurrentQueue<AsyncRenderResult>();

        private readonly Dictionary<int, Dictionary<string, ISubstanceInput>> _inputsTable = new Dictionary<int, Dictionary<string, ISubstanceInput>>();

        private readonly Dictionary<int, Dictionary<string, SubstanceOutputTexture>> _outputTable = new Dictionary<int, Dictionary<string, SubstanceOutputTexture>>();

        private SubstanceInputInt2 _resolutionInput;

        protected void Awake()
        {
            if (SubstanceMaterial == null)
                return;

            if (_runtimeHandler != null)
                return;

            _runtimeHandler = SubstanceRuntime.Instance.InitializeInstance(SubstanceMaterial);

            foreach (var graph in SubstanceMaterial.Graphs)
                InitializeGraph(graph);
        }

        private void InitializeGraph(SubstanceGraph graph)
        {
            _inputsTable.Add(graph.Index, new Dictionary<string, ISubstanceInput>());
            _outputTable.Add(graph.Index, new Dictionary<string, SubstanceOutputTexture>());

            graph.RuntimeInitialize(_runtimeHandler);

            foreach (var input in graph.Input)
            {
                _inputsTable[graph.Index].Add(input.Description.Identifier, input);

                if (input.ValueType == SubstanceValueType.Int2 && input.Description.Identifier == "$outputsize")
                    _resolutionInput = input as SubstanceInputInt2;
            }

            foreach (var output in graph.Output)
                _outputTable[graph.Index].Add(output.Description.Identifier, output);
        }

        protected void Update()
        {
            while (_asyncRenderQueue.TryDequeue(out AsyncRenderResult result))
            {
                if (result.Exception != null)
                {
                    result.Tcs.SetException(result.Exception);
                    continue;
                }

                var targetGraph = SubstanceMaterial.Graphs[result.GraphIndex];
                targetGraph.UpdateOutputTextures(result.RenderResult);
                result.Tcs.SetResult(null);
            }
        }

        public void AttachMaterial(SubstanceMaterialInstanceSO material)
        {
            SubstanceMaterial = material;
        }

        protected void OnDestroy()
        {
            if (_runtimeHandler != null)
                _runtimeHandler.Dispose();
        }

        #region Input Handle

        /// <summary>
        /// Update Substance Float Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        /// <param name="graphID">Index for the target graph.</param>
        public void SetInputFloat(string inputName, float value, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Float)
                throw new ArgumentException();

            _runtimeHandler.SetInputFloat(value, input.Index, graphID);
        }

        /// <summary>
        /// Get Substance Float Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        /// <param name="graphID">Index for the target graph.</param>
        public float GetInputFloat(string inputName, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Float)
                throw new ArgumentException();

            return _runtimeHandler.GetInputFloat(input.Index, graphID);
        }

        /// <summary>
        /// Update Substance Vector2 Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        /// <param name="graphID">Index for the target graph.</param>
        public void SetInputVector2(string inputName, Vector2 value, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Float2)
                throw new ArgumentException();

            _runtimeHandler.SetInputFloat2(value, input.Index, graphID);
        }

        /// <summary>
        /// Get Substance Vector2 Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        /// <param name="graphID">Index for the target graph.</param>
        public Vector2 GetInputVector2(string inputName, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Float2)
                throw new ArgumentException();

            return _runtimeHandler.GetInputFloat2(input.Index, graphID);
        }

        /// <summary>
        /// Update Substance Vector3 Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        /// <param name="graphID">Index for the target graph.</param>
        public void SetInputVector3(string inputName, Vector3 value, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Float3)
                throw new ArgumentException();

            _runtimeHandler.SetInputFloat3(value, input.Index, graphID);
        }

        /// <summary>
        /// Get Substance Vector3 Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        /// <param name="graphID">Index for the target graph.</param>
        public Vector3 GetInputVector3(string inputName, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Float3)
                throw new ArgumentException();

            return _runtimeHandler.GetInputFloat3(input.Index, graphID);
        }

        /// <summary>
        /// Update Substance Vector4 Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        /// <param name="graphID">Index for the target graph.</param>
        public void SetInputVector4(string inputName, Vector4 value, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Float4)
                throw new ArgumentException();

            _runtimeHandler.SetInputFloat4(value, input.Index, graphID);
        }

        /// <summary>
        /// Get Substance Vector4 Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        /// <param name="graphID">Index for the target graph.</param>
        public Vector4 GetInputVector4(string inputName, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Float4)
                throw new ArgumentException();

            return _runtimeHandler.GetInputFloat4(input.Index, graphID);
        }

        /// <summary>
        /// Update Substance Color Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        /// <param name="graphID">Index for the target graph.</param>
        public void SetInputColor(string inputName, Color value, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Float3 && input.ValueType != SubstanceValueType.Float4)
                throw new ArgumentException();

            if (input.ValueType == SubstanceValueType.Float3)
            {
                var vector = new Vector3
                {
                    x = value.r,
                    y = value.g,
                    z = value.b
                };

                _runtimeHandler.SetInputFloat3(vector, input.Index, graphID);
            }
            else if (input.ValueType == SubstanceValueType.Float4)
            {
                _runtimeHandler.SetInputFloat4(value, input.Index, graphID);
            }
        }

        /// <summary>
        /// Get Substance Color
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        /// <param name="graphID">Index for the target graph.</param>
        public Color GetInputColor(string inputName, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Float3 && input.ValueType != SubstanceValueType.Float4)
                throw new ArgumentException();

            if (input.ValueType == SubstanceValueType.Float3)
            {
                Vector3 vector = _runtimeHandler.GetInputFloat3(input.Index, graphID);
                return new Color(vector.x, vector.y, vector.z);
            }
            else if (input.ValueType == SubstanceValueType.Float4)
            {
                Vector4 vector = _runtimeHandler.GetInputFloat4(input.Index, graphID);
                return new Color(vector.x, vector.y, vector.z, vector.w);
            }
            else
                throw new ArgumentException();
        }

        /// <summary>
        /// Update Substance Boolean Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        public void SetInputBool(string inputName, bool value, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Int)
                throw new ArgumentException();

            _runtimeHandler.SetInputInt(value ? 1 : 0, input.Index, graphID);
        }

        /// <summary>
        /// Get Substance Boolean Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        public bool GetInputBool(string inputName, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Int)
                throw new ArgumentException();

            return _runtimeHandler.GetInputInt(input.Index, graphID) == 1;
        }

        /// <summary>
        /// Update Substance Int Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        public void SetInputInt(string inputName, int value, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Int)
                throw new ArgumentException();

            _runtimeHandler.SetInputInt(value, input.Index, graphID);
        }

        /// <summary>
        /// Get Substance Int Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        public int GetInputInt(string inputName, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Int)
                throw new ArgumentException();

            return _runtimeHandler.GetInputInt(input.Index, graphID);
        }

        /// <summary>
        /// Update Substance Vector2 Int Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        public void SetInputVector2Int(string inputName, Vector2Int value, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Int2)
                throw new ArgumentException();

            _runtimeHandler.SetInputInt2(value, input.Index, graphID);
        }

        /// <summary>
        /// Get Substance Vector2 Int Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        public Vector2Int GetInputVector2Int(string inputName, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Int2)
                throw new ArgumentException();

            return _runtimeHandler.GetInputInt2(input.Index, graphID);
        }

        /// <summary>
        /// Update Substance Vector3 Int Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        public void SetInputVector3Int(string inputName, Vector3Int value, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Int3)
                throw new ArgumentException();

            _runtimeHandler.SetInputInt3(value, input.Index, graphID);
        }

        /// <summary>
        /// Get Substance Vector3 Int Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        public Vector3Int GetInputVector3Int(string inputName, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Int3)
                throw new ArgumentException();

            return _runtimeHandler.GetInputInt3(input.Index, graphID);
        }

        /// <summary>
        /// Update Substance Vector4 Int Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        public void SetInputVector4Int(string inputName, int x, int y, int z, int w, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Int4)
                throw new ArgumentException();

            _runtimeHandler.SetInputInt4(x, y, z, w, input.Index, graphID);
        }

        /// <summary>
        /// Get Substance Vector4 Int Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        public int[] GetInputVector4Int(string inputName, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Int4)
                throw new ArgumentException();

            return _runtimeHandler.GetInputInt4(input.Index, graphID);
        }

        /// <summary>
        /// Set Substance String Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        public void SetInputString(string inputName, string value, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.String)
                throw new ArgumentException();

            _runtimeHandler.SetInputString(value, input.Index, graphID);
        }

        /// <summary>
        /// Get Substance String Input
        /// </summary>
        /// <param name="inputName">Name of the input in the SBSAR</param>
        public string GetInputString(string inputName, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.String)
                throw new ArgumentException();

            return _runtimeHandler.GetInputString(input.Index, graphID);
        }

        public SubstanceInputDescription GetInputDescription(string inputName, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            return input.Description;
        }

        public void SetInputTexture(string inputName, Texture2D value, int graphID = 0)
        {
            if (!TryGetInput(inputName, graphID, out ISubstanceInput input))
                throw new ArgumentException();

            if (input.ValueType != SubstanceValueType.Image)
                throw new ArgumentException();

            _runtimeHandler.SetInputTexture2D(value, input.Index, graphID);
        }

        private bool TryGetInput(string name, int graphID, out Input.ISubstanceInput input)
        {
            return _inputsTable[graphID].TryGetValue(name, out input);
        }

        public Vector2Int GetTexturesResolution()
        {
            return _runtimeHandler.GetInputInt2(_resolutionInput.Index, _resolutionInput.GraphID);
        }

        public void SetTexturesResolution(Vector2Int size)
        {
            _runtimeHandler.SetInputInt2(size, _resolutionInput.Index, _resolutionInput.GraphID);
        }

        public bool HasInput(string inputName, int graphID = 0)
        {
            return _inputsTable[graphID].ContainsKey(inputName);
        }

        #endregion Input Handle

        #region Output Handle

        public List<Texture2D> GetGeneratedTextures(int graphID = 0)
        {
            return _outputTable[graphID].Values.Select(a => a.OutputTexture).ToList();
        }

        public Texture2D GetOutputTexture(string inputName, int graphID = 0)
        {
            return _outputTable[graphID][inputName].OutputTexture;
        }

        #endregion Output Handle

        public void Render(int graphID = 0)
        {
            var result = _runtimeHandler.Render(graphID);
            SubstanceMaterial.Graphs[graphID].UpdateOutputTextures(result);
        }

        public Task RenderAsync(int graphID = 0)
        {
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            Task.Run(() =>
            {
                try
                {
                    var result = _runtimeHandler.Render(graphID);
                    _asyncRenderQueue.Enqueue(new AsyncRenderResult(result, graphID, tcs));
                }
                catch (Exception e)
                {
                    _asyncRenderQueue.Enqueue(new AsyncRenderResult(e));
                }
            });

            return tcs.Task;
        }

        private class AsyncRenderResult
        {
            public IntPtr RenderResult { get; }
            public int GraphIndex { get; }
            public TaskCompletionSource<object> Tcs { get; }
            public Exception Exception { get; }

            public AsyncRenderResult(IntPtr renderResult, int graphIndex, TaskCompletionSource<object> tcs)
            {
                RenderResult = renderResult;
                GraphIndex = graphIndex;
                Tcs = tcs;
                Exception = null;
            }

            public AsyncRenderResult(Exception exception)
            {
                Exception = exception;
            }
        }
    }
}