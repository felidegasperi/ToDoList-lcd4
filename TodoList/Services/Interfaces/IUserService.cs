using TodoList.Data.DTO;
using TodoList.Data.Entities;

namespace TodoList.Services.Interfaces
{
    public interface IUserService
    {
        //metodos que se tienen q implementar y lo que recibe 
        List<UserDTO> GetAllUsers();
        public UserDTO GetUserById(int userId);
        public UserDTO CreateUser(CreateUserDTO createUserDTO);
    }
}
