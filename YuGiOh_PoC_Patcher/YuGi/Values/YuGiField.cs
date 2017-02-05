using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace YuGiOh_PoC_Patcher.YuGi.Values
{
    public class YuGiField : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private YuGiPoint _deckOffset;
        private YuGiPoint _graveyardOffset;
        private YuGiPoint _fusionOffset;
        private YuGiPoint _fieldEffectOffset;
        private YuGiPoint _handOffset;
        private YuGiPoint _removedFromGameOffset;
        private YuGiPointBundle _magicCards;
        private YuGiPointBundle _monsterCards;

        public YuGiPoint DeckOffset
        {
            get { return _deckOffset; }
            set
            {
                _deckOffset = value;
                if (value == null) return;
                _deckOffset.PropertyChanged += ValueChanged;
            }
        }
        public YuGiPoint GraveyardOffset
        {
            get { return _graveyardOffset; }
            set
            {
                _graveyardOffset = value;
                if (value == null) return;
                _graveyardOffset.PropertyChanged += ValueChanged;
            }
        }
        public YuGiPoint FusionOffset
        {
            get { return _fusionOffset; }
            set
            {
                _fusionOffset = value;
                if (value == null) return;
                _fusionOffset.PropertyChanged += ValueChanged;
            }
        }
        public YuGiPoint FieldEffectOffset
        {
            get { return _fieldEffectOffset; }
            set
            {
                _fieldEffectOffset = value;
                if (value == null) return;
                _fieldEffectOffset.PropertyChanged += ValueChanged;
            }
        }
        public YuGiPoint HandOffset
        {
            get { return _handOffset; }
            set
            {
                _handOffset = value;
                if (value == null) return;
                _handOffset.PropertyChanged += ValueChanged;
            }
        }
        public YuGiPoint RemovedFromGameOffset
        {
            get { return _removedFromGameOffset; }
            set
            {
                _removedFromGameOffset = value;
                if (value == null) return;
                _removedFromGameOffset.PropertyChanged += ValueChanged;
            }
        }

        public YuGiPointBundle MagicCards
        {
            get { return _magicCards; }
            set
            {
                _magicCards = value;
                if (value == null) return;
                _magicCards.PropertyChanged += ValueChanged;
            }
        }
        public YuGiPointBundle MonsterCards
        {
            get { return _monsterCards; }
            set
            {
                _monsterCards = value;
                if (value == null) return;
                _monsterCards.PropertyChanged += ValueChanged;
            }
        }



        /// <summary>
        /// Copies the values of the given instance to the current instance
        /// </summary>
        /// <param name="field"></param>
        public void CopyValues(YuGiField field)
        {
            HandOffset.CopyValues(field.HandOffset);
            DeckOffset.CopyValues(field.DeckOffset);
            GraveyardOffset.CopyValues(field.GraveyardOffset);
            FusionOffset.CopyValues(field.FusionOffset);
            FieldEffectOffset.CopyValues(field.FieldEffectOffset);
            RemovedFromGameOffset.CopyValues(field.RemovedFromGameOffset);

            MagicCards.CopyValues(field.MagicCards);
            MonsterCards.CopyValues(field.MonsterCards);
        }

        public void LoadValue(BinaryReader reader, bool update = false)
        {
            HandOffset.LoadValue(reader, update);
            DeckOffset.LoadValue(reader, update);
            GraveyardOffset.LoadValue(reader, update);
            FusionOffset.LoadValue(reader, update);
            FieldEffectOffset.LoadValue(reader, update);
            RemovedFromGameOffset.LoadValue(reader, update);

            MagicCards.LoadValue(reader, update);
            MonsterCards.LoadValue(reader, update);
        }

        public void PatchValue(BinaryWriter writer)
        {
            HandOffset.PatchValue(writer);
            DeckOffset.PatchValue(writer);
            GraveyardOffset.PatchValue(writer);
            FusionOffset.PatchValue(writer);
            FieldEffectOffset.PatchValue(writer);
            RemovedFromGameOffset.PatchValue(writer);

            MagicCards.PatchValue(writer);
            MonsterCards.PatchValue(writer);
        }

        public void PatchDefault(BinaryWriter writer)
        {
            HandOffset.PatchDefault(writer);
            DeckOffset.PatchDefault(writer);
            GraveyardOffset.PatchDefault(writer);
            FusionOffset.PatchDefault(writer);
            FieldEffectOffset.PatchDefault(writer);
            RemovedFromGameOffset.PatchDefault(writer);

            MagicCards.PatchDefault(writer);
            MonsterCards.PatchDefault(writer);
        }


        private void ValueChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}