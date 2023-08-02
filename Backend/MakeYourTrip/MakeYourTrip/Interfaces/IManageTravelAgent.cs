using System.Numerics;
using LoginAndRegister.Models;
using LoginAndRegister.Models.DTO;

namespace LoginAndRegister.Interfaces
{
    public interface IManageTravelAgent
    {
        public Task<UserDTO?> AgentRegistration(TravelAgentRegisterDTO user);
        public Task<TravelAgent?> AgentProfile(string email);
        public Task<UpdateDTO?> UpdateTravelAgent(UpdateDTO agent);
        public Task<string?> GetAgentCity(string email);
    }
}
