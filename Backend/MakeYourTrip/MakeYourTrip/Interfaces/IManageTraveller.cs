using System.Numerics;
using LoginAndRegister.Models;
using LoginAndRegister.Models.DTO;

namespace LoginAndRegister.Interfaces
{
    public interface IManageTraveller
    {
        public Task<UserDTO?> TravellerRegistration(TravellerRegisterDTO traveller);
        public Task<Traveller?> TravellerProfile(string email);
        public Task<TravellerUpdateDTO?> UpdateTraveller(TravellerUpdateDTO traveller);
        public Task<ICollection<TravelAgent?>?> SearchAgentForTraveller(string name);
       
    }
}
