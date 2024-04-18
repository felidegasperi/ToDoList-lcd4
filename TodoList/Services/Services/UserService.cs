using TodoList.Data.Context;
using TodoList.Data.DTO;
using TodoList.Data.Entities;
using TodoList.Services.Interfaces;

namespace TodoList.Services.Services
{
    public class UserService : IUserService
    {
        private readonly ToDoListContext _context;

        public UserService(ToDoListContext context) 
        { 
            _context = context; //inyeccion de dep
        }

        public List<UserDTO> GetAllUsers() 
        {
            try
            {
                // Consulta todos los usuarios desde el contexto
                var users = _context.Users.ToList();
                //return _context.Users.ToList();

                // Mapea cada objeto User a un objeto UserDTO
                var usersDTO = users.Select(u => new UserDTO
                {
                    Id_user = u.Id_user,
                    Name = u.Name,
                    Email = u.Email,
                    Address = u.Address,
                    //si agrego la lista de todo la tendria que mapear aca.
                }).ToList();

                return usersDTO;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error al obtener todos los users: {ex.Message}", ex);
            }
            
        }

        public UserDTO GetUserById(int userid)
        {
            try
            {
                //busca el usuario con el id que se ingreso
                var user = _context.Users.SingleOrDefault(u => u.Id_user == userid);
                if (user == null)
                    throw new Exception($"No se encontro un usuario con el id: {userid}");

                return new UserDTO
                {
                    Id_user = user.Id_user,
                    Name = user.Name,
                    Email = user.Email,
                    Address = user.Address,
                };
                
            }
            catch (Exception)
            {
                throw new Exception($"Error al obtener el usuario con el id: {userid}");
            }
        }

        public UserDTO CreateUser(CreateUserDTO createUserDTO)
        {
            try
            {
                // Crear un nuevo objeto User con los datos del DTO
                var newUser = new User
                {
                    Name = createUserDTO.Name,
                    Email = createUserDTO.Email,
                    Address = createUserDTO.Address
                };

                //agregamos el new user a la DB
                _context.Users.Add(newUser);
                _context.SaveChanges();

                return new UserDTO
                {
                    Id_user = newUser.Id_user,
                    Name = newUser.Name,
                    Email = newUser.Email,
                    Address = newUser.Address
                };
            }
            catch (ArgumentException ex)
            {
                // mensajes de necesarios
                throw ex;
            }
            catch (Exception)
            {
                throw new Exception("Error al crear el usuario");
            }
        }
    }
}
