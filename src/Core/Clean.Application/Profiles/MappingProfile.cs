
using AutoMapper;
using Clean.Application.Features.Bottles.Commands.CreateBottle;
using Clean.Application.Features.Bottles.Commands.UpdateBottle;
using Clean.Application.Features.Bottles.Queries.GetAllBottles;
using Clean.Application.Features.Bottles.Queries.GetBollteById;
using Clean.Application.Features.Categories.Commands.CreateCategory;
using Clean.Application.Features.Categories.Commands.StoredProcedure;
using Clean.Application.Features.Categories.Queries.GetCategoriesList;
using Clean.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Clean.Application.Features.Employees.Commands.CreateEmployee;
using Clean.Application.Features.Employees.Queries.GetAllEmployees;
using Clean.Application.Features.Employees.Queries.GetEmployeeExport;
using Clean.Application.Features.Events.Commands.CreateEvent;
using Clean.Application.Features.Events.Commands.Transaction;
using Clean.Application.Features.Events.Commands.UpdateEvent;
using Clean.Application.Features.Events.Queries.GetEventDetail;
using Clean.Application.Features.Events.Queries.GetEventsExport;
using Clean.Application.Features.Events.Queries.GetEventsList;
using Clean.Application.Features.Orders.Queries.GetOrdersForMonth;
using Clean.Application.Features.Students.Commands.CreateStudent;
using Clean.Application.Features.Students.Commands.UpdateStudent;
using Clean.Application.Features.Students.Queries.GetAllStudents;
using Clean.Application.Features.Students.Queries.GetStudentById;
using Clean.Domain.Entities;

namespace Clean.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {          
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, TransactionCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeListDto>().ReverseMap();
            CreateMap<Employee, EmployeeExportDto>().ReverseMap();

            CreateMap<Student, Student>().ReverseMap();
            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentCommand>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();
            CreateMap<Student, StudentListDto>().ReverseMap();
            CreateMap<Student, GetStudentByIdDto>().ReverseMap();

            CreateMap<Bottle, Bottle>().ReverseMap();
            CreateMap<Bottle, CreateBottleCommand>().ReverseMap();
            CreateMap<Bottle, CreateBottleDto>().ReverseMap();
            CreateMap<Bottle, UpdateBottleCommand>().ReverseMap();
            CreateMap<Bottle, UpdateBottleDto>().ReverseMap();
            CreateMap<Bottle, BottleListDto>().ReverseMap();
            CreateMap<Bottle, GetBottleByIdDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, StoredProcedureCommand>();
            CreateMap<Category, StoredProcedureDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();
        }
    }
}
