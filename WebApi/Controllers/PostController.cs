﻿using Application.DTOs.General;
using Application.DTOs.Posts;
using Application.MediatR.Posts.Commands;
using Application.MediatR.Posts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;
    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpPost("post")]
    public async Task<IActionResult> CreatePost(CreatePostDTO command)
    {
        var result = await _mediator.Send(new CreatePost(command));

        return Ok(result);
    }

    [HttpGet("post")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var result = await _mediator.Send(new GetPostById(id));

        return Ok(result);
    }

    [HttpGet("post-full")]
    public async Task<IActionResult> GetPostFull(int id)
    {
        var result = await _mediator.Send(new GetPostFull(id));

        return Ok(result);
    }

    [HttpGet("post-lite-list")]
    public async Task<IActionResult> GetPostLiteList([FromQuery] PaginationRequestDTO dto)
    {
        var result = await _mediator.Send(new GetPostLiteList(dto));

        return Ok(result);
    }

    [HttpGet("pool-option-list")]
    public async Task<IActionResult> GetPoolOptionList(int id)
    {
        var result = await _mediator.Send(new PoolOptionsForVoteByPostId(id));

        return Ok(result);
    }

    [Authorize]
    [HttpGet("post-menu")]
    public async Task<IActionResult> GetPostListTable([FromQuery] PaginationRequestDTO paginationRequestDTO)
    {
        var result = await _mediator.Send(new GetTableOfPostList(paginationRequestDTO));

        return Ok(result);
    }

    [Authorize]
    [HttpPut("post")]
    public async Task<IActionResult> EditPost(PostEditDTO postEditDTO)
    {
        var result = await _mediator.Send(new EditPost(postEditDTO));

        return Ok(result);
    }

    [Authorize]
    [HttpDelete("post")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var result = await _mediator.Send(new DeletePostById(id));

        return Ok(result);
    }
}