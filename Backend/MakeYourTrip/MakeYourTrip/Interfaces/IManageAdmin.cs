using System.Numerics;
using LoginAndRegister.Models.DTO;
using LoginAndRegister.Models;

namespace LoginAndRegister.Interfaces
{
    public interface IManageAdmin
    {
        public Task<UserDTO?> AdminRegistration(AdminRegisterDTO user);
        public Task<Admin?> GetAdminProfile(string email);
        public Task<ICollection<TravelAgent?>?> ViewAllAgents();
        public Task<ICollection<TravelAgent?>?> ViewAllUnapprovedAgents();
        public Task<ICollection<TravelAgent?>?> ViewAllApprovedAgents();
        public Task<StatusDTO?> ChangeTravelAgentStatus(StatusDTO userApproval);
        public Task<TravelAgent?> DeleteTravelAgent(string email);
        public Task<ICollection<Traveller?>?> ViewAllTravellers();       
    }
}
