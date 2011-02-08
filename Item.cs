using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public class Item
    {
        public event EventHandler NameChanged;
        private void OnNameChanged()
        {
            if (NameChanged != null)
                NameChanged(this, EventArgs.Empty);
        }
        public event EventHandler WeightPoundsChanged;
        private void OnWeightPoundsChanged()
        {
            if (WeightPoundsChanged != null)
                WeightPoundsChanged(this, EventArgs.Empty);
        }
        public event EventHandler GoldValueChanged;
        private void OnGoldValueChanged()
        {
            if (GoldValueChanged != null)
                GoldValueChanged(this, EventArgs.Empty);
        }
        string name;
        float goldValue;
        float weight;
        public string Name { get { return name; } set { name = value; OnNameChanged(); } }
        public float GoldValue { get { return goldValue; } set { goldValue = value; OnGoldValueChanged(); } }
        public float WeightPounds 
        { 
            get { return weight; } 
            set
            {
                weight = value;
                OnWeightPoundsChanged();
            }
        }
        public float WeightKilos
        {
            get { return weight * 0.45359f; }
            set { weight = value / 0.45359f;
            OnWeightPoundsChanged();
            }
        }
        public Item(string name, float goldValue, float weight)
        {
            this.name = name;
            this.goldValue = goldValue;
            this.weight = weight;
        }
    }
}
