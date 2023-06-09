﻿using FrameWork.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application.Comment
{
	public class CommentApplication : ICommentApplication
	{
		private readonly ICommentRepository _commentRepository;
		private readonly IUnitOfWork _unitOfWork;
		public CommentApplication(ICommentRepository comment, IUnitOfWork unitOfWork)
		{
			_commentRepository = comment;
			_unitOfWork = unitOfWork;
		}

		public void Add(AddComment command)
		{
			_unitOfWork.BeginTran();
			var comment =
				new Domain.CommentAgg.Comment(command.Name, command.Email, command.Message, command.ArticleId);
			_commentRepository.Create(comment);
			_unitOfWork.CommitTran();
		}

		public List<CommentViewModel> GetList()
		{
			return _commentRepository.GetList();
		}

		public void Confirm(long id)
		{
			_unitOfWork.BeginTran();
			var comment = _commentRepository.Get(id);
			comment.Confirm();
			_unitOfWork.CommitTran();
		}

		public void Cancel(long id)
		{
			_unitOfWork.BeginTran();
			var comment = _commentRepository.Get(id);
			comment.Cancel();
			_unitOfWork.CommitTran();
		}
	}
}
