using System;
using UnityEngine.Experimental.UIElements;
using UnityEngine;
using UnityEditor.Graphing.Util;
using UnityEditor.ShaderGraph;
using UnityEditor.ShaderGraph.Drawing;
using UnityEditor.ShaderGraph.Drawing.Controls;
using UnityEngine.Experimental.Rendering.HDPipeline;

namespace UnityEditor.Experimental.Rendering.HDPipeline.Drawing
{
    class DecalSettingsView : VisualElement
    {
        DecalMasterNode m_Node;

        Label CreateLabel(string text, int indentLevel)
        {
            string label = "";
            for (var i = 0; i < indentLevel; i++)
            {
                label += "    ";
            }
            return new Label(label + text);
        }

        public DecalSettingsView(DecalMasterNode node)
        {
            m_Node = node;
            PropertySheet ps = new PropertySheet();
            
            int indentLevel = 0;

            ps.Add(new PropertyRow(CreateLabel("Affects Albedo", indentLevel)), (row) =>
            {
                row.Add(new Toggle(), (toggle) =>
                {
                    toggle.value = m_Node.affectsAlbedo.isOn;
                    toggle.OnToggleChanged(ChangeAffectsAlbedo);
                });
            });

            ps.Add(new PropertyRow(CreateLabel("Affects Normal", indentLevel)), (row) =>
            {
                row.Add(new Toggle(), (toggle) =>
                {
                    toggle.value = m_Node.affectsNormal.isOn;
                    toggle.OnToggleChanged(ChangeAffectsNormal);
                });
            });

            ps.Add(new PropertyRow(CreateLabel("Affects Metal", indentLevel)), (row) =>
            {
                row.Add(new Toggle(), (toggle) =>
                {
                    toggle.value = m_Node.affectsMetal.isOn;
                    toggle.OnToggleChanged(ChangeAffectsMetal);
                });
            });

            ps.Add(new PropertyRow(CreateLabel("Affects AO", indentLevel)), (row) =>
            {
                row.Add(new Toggle(), (toggle) =>
                {
                    toggle.value = m_Node.affectsAO.isOn;
                    toggle.OnToggleChanged(ChangeAffectsAO);
                });
            });

            ps.Add(new PropertyRow(CreateLabel("Affects Smoothness", indentLevel)), (row) =>
            {
                row.Add(new Toggle(), (toggle) =>
                {
                    toggle.value = m_Node.affectsSmoothness.isOn;
                    toggle.OnToggleChanged(ChangeAffectsSmoothness);
                });
            });
            Add(ps);
        }

        void ChangeAffectsAlbedo(ChangeEvent<bool> evt)
        {
            m_Node.owner.owner.RegisterCompleteObjectUndo("Affects Albedo Change");
            ToggleData td = m_Node.affectsAlbedo;
            td.isOn = evt.newValue;
            m_Node.affectsAlbedo = td;
        }

        void ChangeAffectsNormal(ChangeEvent<bool> evt)
        {
            m_Node.owner.owner.RegisterCompleteObjectUndo("Affects Normal Change");
            ToggleData td = m_Node.affectsNormal;
            td.isOn = evt.newValue;
            m_Node.affectsNormal = td;
        }

        void ChangeAffectsMetal(ChangeEvent<bool> evt)
        {
            m_Node.owner.owner.RegisterCompleteObjectUndo("Affects Metal Change");
            ToggleData td = m_Node.affectsMetal;
            td.isOn = evt.newValue;
            m_Node.affectsMetal = td;            
        }

        void ChangeAffectsAO(ChangeEvent<bool> evt)
        {
            m_Node.owner.owner.RegisterCompleteObjectUndo("Affects AO Change");
            ToggleData td = m_Node.affectsAO;
            td.isOn = evt.newValue;
            m_Node.affectsAO = td;
        }

        void ChangeAffectsSmoothness(ChangeEvent<bool> evt)
        {
            m_Node.owner.owner.RegisterCompleteObjectUndo("Affects Smoothness Change");
            ToggleData td = m_Node.affectsSmoothness;
            td.isOn = evt.newValue;
            m_Node.affectsSmoothness = td;
        }
    }
}
