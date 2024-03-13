using DatingApp.Server.DTOs;
using DatingApp.Server.Entities;
using DatingApp.Server.Helpers;

namespace DatingApp.Server.Interfaces
{
	public interface IMessageRepository
	{
		void AddMessage(Message message);
		void DeleteMessage(Message message);
		Task<Message> GetMessage(int id);
		Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);
		Task<IEnumerable<MessageDto>> GetMessageThread(string currentUserName, string recipientName);
		Task<bool> SaveAllAsync();
	}
}
