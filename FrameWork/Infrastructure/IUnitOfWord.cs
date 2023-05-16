namespace FrameWork.Infrastructure
{
	public interface IUnitOfWork
	{
		void BeginTran();
		void CommitTran();
		void Rollback();
	}
}