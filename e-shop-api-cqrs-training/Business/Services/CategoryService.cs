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
    private readonly IAppMapper _appMapper;

    public CategoryService(IMediator mediator, IAppMapper appMapper)
    {
        _mediator = mediator;
        _appMapper = appMapper;
    }

    public async Task<CategoryReadDto> Create(CategoryCreateDto dto)
    {
        await new CategoryCreateDtoValidator().ValidateAndThrowAsync(dto);
        //check cet merde
        await CheckCategoryDoesNotExist(dto);

        var command = new CreateCategoryCommand { Name = dto.Name };

        Category category = await _mediator.Send(command);

        return _appMapper.ToReadDto<Category, CategoryReadDto>(category);
    }

    public async Task<IEnumerable<CategoryReadDto>> GetAll()
    {
        List<CategoryReadDto> categoryReadDtoList = new List<CategoryReadDto>();

        IEnumerable<Category> command = await _mediator.Send(new GetAllCategoryQuery());

        foreach (Category category in command)
        {
            categoryReadDtoList.Add(_appMapper.ToReadDto<Category, CategoryReadDto>(category));
        }

        return categoryReadDtoList;
    }

    public async Task<CategoryReadDto> GetOne(Guid guid)
    {
        var command = new GetCategoryByIdQuery { Id = guid };

        Category? category = await _mediator.Send(command);
        
        return _appMapper.ToReadDto<Category, CategoryReadDto>(category);
    }
    
    public async Task<CategoryReadDto> GetOne(string name)
    {
        var command = new GetCategoryByNameQuery { Name = name };

        Category? category = await _mediator.Send(command);

        return _appMapper.ToReadDto<Category, CategoryReadDto>(category);
    }
    
    private async Task CheckCategoryDoesNotExist(CategoryCreateDto dto)
    {
        Category? category = await _mediator.Send(new GetCategoryByNameQuery { Name = dto.Name });

        if (category is not null) throw new ConflictException<Category>();
    }
}
