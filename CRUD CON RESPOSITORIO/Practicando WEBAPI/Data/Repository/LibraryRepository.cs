using Practicando_WEBAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicando_WEBAPI.Data.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private List<BreedEntity> breeds = new List<BreedEntity>(){
            new BreedEntity(){Id=1,Name="Orcs",DefaultColor="Green",Reign="Draenor",TypesofUnity=13,Heroes=new List<string>{ "Shadow Hunter", "Far Seer", "Blademaster", "Tauren Chieftain"},ArmyName="The Horde",Difficulty="Medium",Rating=76.4m},
            new BreedEntity(){Id=2,Name="Undeads",DefaultColor="Black",Reign="BurningLegion",TypesofUnity=12,Heroes=new List<string>{ "Death Knight", "Dread Lord", "Lich", "Crypt Lord"},ArmyName="The Scourge",Difficulty="Hard",Rating=56.8m},
            new BreedEntity(){Id=3,Name="Humans",DefaultColor="White",Reign="Lordaeron",TypesofUnity=13,Heroes=new List<string>{ "Paladin", "Archmage", "Mountain King", "Blood Mage"},ArmyName="The Alliance",Difficulty="Easy",Rating=67.2m},
            new BreedEntity(){Id=4,Name="NightElves",DefaultColor="Blue",Reign="Kalimdor",TypesofUnity=11,Heroes=new List<string>{ "Demon Hunter", "Keeper of the Grove", "Priestess of the Moon", "Warden"},ArmyName="The NightElves of Kalimdor",Difficulty="Medium",Rating=70.7m}
        };
        public BreedEntity GetBreed(int breedId)
        {
            return breeds.FirstOrDefault(c => c.Id == breedId);
        }
        public BreedEntity CreateBreed(BreedEntity breedEntity)
        {
            int breedId;
            if (breeds.Count() == 0)
            {
                breedId = 1;
            }
            else
            {
                breedId = breeds.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            }
            breedEntity.Id = breedId;
            breeds.Add(breedEntity);
            return breedEntity;
        }

        public bool DeleteBreed(int breedId)
        {
            var breedToDelete = GetBreed(breedId);
            breeds.Remove(breedToDelete);
            return true;
        }

       

        public IEnumerable<BreedEntity> GetBreeds()
        {
            return breeds;
        }

        public BreedEntity UpdateBreed(BreedEntity breedEntity)
        {
            var breedtoUpdate = GetBreed(breedEntity.Id);
            breedtoUpdate.Name = breedEntity.Name ?? breedtoUpdate.Name;
            breedtoUpdate.Rating = breedEntity.Rating ?? breedtoUpdate.Rating;
            breedtoUpdate.Reign = breedEntity.Reign ?? breedtoUpdate.Reign;
            breedtoUpdate.Heroes = breedEntity.Heroes ?? breedtoUpdate.Heroes;
            breedtoUpdate.Difficulty = breedEntity.Difficulty ?? breedtoUpdate.Difficulty;
            breedtoUpdate.ArmyName = breedEntity.ArmyName ?? breedtoUpdate.ArmyName;
            breedtoUpdate.DefaultColor = breedEntity.DefaultColor ?? breedtoUpdate.DefaultColor;
            breedtoUpdate.TypesofUnity = breedEntity.TypesofUnity ?? breedtoUpdate.TypesofUnity;
            return breedtoUpdate;
        }
    }
}
