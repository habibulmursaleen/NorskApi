using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.Interfaces.Services;
using NorskApi.Infrastructure.Common;
using NorskApi.Infrastructure.Persistance.DBContext;
using NorskApi.Infrastructure.Persistance.Interceptors;
using NorskApi.Infrastructure.Persistance.Repositories;
using NorskApi.Infrastructure.Services;

namespace NorskApi.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddDbContext<NorskApiDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<PublishDomainEventsInterceptor>();

            services.AddScoped<ILocalExpressionRepository, LocalExpressionRepository>();
            services.AddScoped<IDiscussionRepository, DiscussionRepository>();
            services.AddScoped<IDictationRepository, DictationRepository>();
            services.AddScoped<IPodcastRepository, PodcastRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IRoleplayRepository, RoleplayRepository>();
            services.AddScoped<ITaskWorkRepository, TaskWorkRepository>();
            services.AddScoped<IGrammarTopicRepository, GrammarTopicRepository>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IEssayRepository, EssayRepository>();
            services.AddScoped<IGrammarRuleRepository, GrammarRuleRepository>();
            services.AddScoped<ISubjunctionRepository, SubjunctionRepository>();
            services.AddScoped<IWordRepository, WordRepository>();

            services.AddScoped<IQueryParamsBaseBuilder, QueryParamsBaseBuilder>();
            services.AddScoped<IQueryParamsWithEssayBuilder, QueryParamsWithEssayBuilder>();
            services.AddScoped<IQuizQueryParamsBuilder, QuizQueryParamsBuilder>();

            return services;
        }
    }
}
