namespace AspBackend.Utilities ;

    /// <summary>
    /// Класс для маппинга
    /// </summary>
    public class AutomapperSettings : Profile
    {
        public AutomapperSettings()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponce>();


            CreateMap<UserRegistrationRequest, User>();
            CreateMap<User, UserRegistrationResponce>();

            CreateMap<UserRegistrationRequest, Account>();
            CreateMap<Account, UserRegistrationResponce>();

            CreateMap<UserAuthorizationRequest, User>();
            CreateMap<User, UserAuthorizationResponce>();

            CreateMap<UserAuthorizationRequest, Account>();
            CreateMap<Account, UserAuthorizationResponce>();

            #region Маппинг для создания задачи

            CreateMap<CreateTodoRequest, Todo>();
            CreateMap<Todo, CreateTodoResponce>();

            CreateMap<CreateTodoRequest, Status>();
            CreateMap<Status, CreateTodoResponce>();

            CreateMap<CreateTodoRequest, Priority>();
            CreateMap<Priority, CreateTodoResponce>();

            #endregion

            #region Маппинг для обновления задачи

            CreateMap<UpdateTodoRequest, Todo>();
            CreateMap<Todo, UpdateTodoResponce>();

            #endregion

            #region Маппинг для создания/удаления пользователя у задачи

            CreateMap<UserTodoRequest, UserTodo>();
            CreateMap<UserTodo, UserTodoResponce>();

            #endregion

            #region Маппинг для создания/удаления проектов

            CreateMap<ProjectRequest, Project>();
            CreateMap<Project, ProjectResponce>();

            #endregion

            #region Маппинг для создания/удаления задач у проекта

            CreateMap<ProjectTodoRequest, ProjectTodo>();
            CreateMap<ProjectTodo, ProjectTodoResponce>();

            #endregion

            #region Маппинг для добавление/удаления пользователей у проекта

            CreateMap<ProjectUserRequest, UserProject>();
            CreateMap<UserProject, ProjectUserResponce>();

            #endregion
        }
    }