using AutoMapper;
using Business.Dtos.Category;
using Business.Interfaces;
using Business.Validators;
using Dal.Commands.Category;
using Dal.Entities;
using Dal.Queries.Category;
using Error;
using FluentValidation;
using MediatR;

namespace Business.Services;

public class CategoryService : ICategoryService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoryService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<CategoryReadDto> Create(CategoryCreateDto dto)
    {
        await new CategoryCreateDtoValidator().ValidateAndThrowAsync(dto);
        //check cet merde
        await CheckCategoryDoesNotExist(dto);

        Category? category = await _mediator.Send(new CreateCategoryCommand { Name = dto.Name });
        return _mapper.Map<CategoryReadDto>(category);
    }

    public async Task<IEnumerable<CategoryReadDto>> GetAll()
    {
        IEnumerable<Category> categories = await _mediator.Send(new GetAllCategoryQuery());
        return _mapper.Map<IEnumerable<CategoryReadDto>>(categories);
    }

    public async Task<CategoryReadDto> GetOne(Guid guid)
    {
        Category? category = await _mediator.Send(new GetCategoryByIdQuery { Id = guid });
        return _mapper.Map<CategoryReadDto>(category);
    }

    public async Task<CategoryReadDto> GetOne(string name)
    {
        Category? category = await _mediator.Send(new GetCategoryByNameQuery { Name = name });
        return _mapper.Map<CategoryReadDto>(category);
    }

    private async Task CheckCategoryDoesNotExist(CategoryCreateDto dto)
    {
        Category? category = await _mediator.Send(new GetCategoryByNameQuery { Name = dto.Name });

        if (category is not null) throw new ConflictException<Category>();
    }
}
