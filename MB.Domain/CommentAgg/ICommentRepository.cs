﻿using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg
{
	public interface ICommentRepository
	{
		void CreateAndSave(Comment entity);
		List<CommentViewModel> GetList();
		void Save();
		Comment Get(long id);
	}
}
