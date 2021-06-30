//using iTextSharp.tool.xml.parser;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    public abstract class Action : ScriptableObject
    {
        public abstract void act(StateController controler);
    }
}