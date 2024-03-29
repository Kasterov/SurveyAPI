﻿using Application.DTOs.Posts;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Abstractions.Posts;

public interface IPostRepository
{
    public Task<IEnumerable<PostLiteDTO>> GetAll();

    public Task<IEnumerable<PostTableFullDTO>> GetTablePostList(int userId);

    public Task<bool?> PossibleToRevote(int postId);

    public Task<PostFullDTO?> GetPostFullDTO(int id);
    public Task<Post> GetById(int id);
    public Task<PostEditDTO> GetPostEditById(int id);
    public Task<Post> Add(Post post);

    public Task<Post> Update(Post post);

    public Task<Post> Delete(int postId, int userId);
}
