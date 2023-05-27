using Hotel_Management_Bigbang_Assessment1_.Models;

namespace Hotel_Management_Bigbang_Assessment1_.Repository
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetRooms();
        Task<Room> GetRoomById(int id);
        Task<int> CreateRoom(Room room);
        Task UpdateRoom(Room room);
        Task DeleteRoom(int id);
    }
}
