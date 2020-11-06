

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConanTheCSharpian.Core
{
    public class HeroParty : Party<Hero>
    {
        public List<Hero> characters = new List<Hero>();
        public HeroParty(Battlefield battlefield, ICharacterController characterController, int characterAmount)
            : base (battlefield, characterController, characterAmount)
        { }

        protected override void CreateCharacterInstances(int characterAmount)
        {

            for (int i = 0; i < characterAmount; i++)
            {
                Characters.Add(SetCharacter(characterAmount));
                characterAmount = -1;
            }

            
            

        }

        protected override Hero SetCharacter(int characterFlag)
        {
            Random _random = new Random();
            int _index;
            characters.Add(new Barbarian());
            characters.Add(new Mage());
            characters.Add(new Ranger());
            characters.Add(new Paladin());
            if (characterFlag >= Characters.Count)
            {
                _index = _random.Next(0, characters.Count - 1);
                return characters[_index];
            }
                
            return characters[characterFlag];

            
            
        }

        //protected Hero RetHeroSelected(CharacterType userControlledCharacterType)
        //{
           //L'eccezione che genera è che non viene creata l'istanza selezionata dall'utente. Avrei dovuto scrivere un metodo, separato per creare il campione selezionato dall'utente visto
           //che la logica era di scorrere la lista di oggetti Hero
        //}
    }
}
