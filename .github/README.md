# GitHub Actions Workflows

Данный репозиторий содержит набор GitHub Actions workflows для автоматизации CI/CD процессов для ASP.NET Core проекта клиники.

## Доступные Workflows

### 1. CI Pipeline (`ci.yml`)
**Триггеры:** Push в `main`/`develop`, Pull Request в `main`/`develop`

**Функции:**
- Сборка .NET 9.0 проектов
- Восстановление NuGet зависимостей
- Запуск тестов (если есть)
- Кэширование NuGet пакетов для ускорения сборки

**Использование:**
```bash
# Локальная сборка
dotnet restore Clinic/Clinic.sln
dotnet build Clinic/Clinic.sln --configuration Release
dotnet test Clinic/Clinic.sln --configuration Release
```

### 2. Docker Build and Deploy (`docker.yml`)
**Триггеры:** Push в `main`, теги `v*`, Pull Request в `main`

**Функции:**
- Создание Docker образа для API
- Публикация образа в GitHub Container Registry
- Поддержка версионирования образов

**Использование:**
```bash
# Сборка Docker образа
docker build -f Clinic/Clinic.Api/Dockerfile -t clinic-api:latest .

# Запуск контейнера
docker run -p 8080:8080 clinic-api:latest
```

### 3. Azure Deploy (`azure-deploy.yml`)
**Триггеры:** Push в `main`, ручной запуск

**Функции:**
- Публикация .NET проекта
- Деплой в Azure App Service

**Необходимые Secrets:**
- `AZURE_WEBAPP_NAME` - имя Azure App Service
- `AZURE_WEBAPP_PUBLISH_PROFILE` - профиль публикации

**Настройка Azure:**
1. Создайте Azure App Service
2. Скачайте профиль публикации
3. Добавьте Secrets в GitHub репозиторий

## Структура файлов

```
.github/
├── workflows/
│   ├── ci.yml              # Основной CI pipeline
│   ├── docker.yml          # Docker сборка и деплой
│   ├── azure-deploy.yml    # Azure App Service деплой
│   └── setup_pr.yml        # Автоматическая настройка PR
├── ISSUE_TEMPLATE/
│   └── вопрос-по-лабораторной.md
├── PULL_REQUEST_TEMPLATE.md
└── DISCUSSION_TEMPLATE/
    └── questions.yml

Clinic/
├── Clinic.Api/
│   ├── Dockerfile          # Docker образ для API
│   └── .dockerignore       # Исключения для Docker сборки
└── ...
```

## Настройка проекта

### Для локальной разработки:
```bash
# Восстановление зависимостей
dotnet restore Clinic/Clinic.sln

# Сборка проекта
dotnet build Clinic/Clinic.sln

# Запуск API
dotnet run --project Clinic/Clinic.Api

# Запуск с настройками разработки
cd Clinic/Clinic.Api
dotnet run
```

### Для Docker:
```bash
# Сборка образа
docker build -f Clinic/Clinic.Api/Dockerfile -t clinic-api .

# Запуск с базой данных (пример)
docker run -p 8080:8080 -e ConnectionStrings__DefaultConnection="Server=host.docker.internal;Database=ClinicDb;User=sa;Password=YourPassword;" clinic-api
```

## Переменные окружения

Для работы проекта необходимо настроить следующие переменные окружения:

### Development:
- `ASPNETCORE_ENVIRONMENT=Development`
- `ConnectionStrings__DefaultConnection` - строка подключения к БД

### Production:
- `ASPNETCORE_ENVIRONMENT=Production`
- `ConnectionStrings__DefaultConnection` - строка подключения к продакшн БД

## Дополнительные возможности

### Добавление тестов:
1. Создайте тестовый проект: `dotnet new xunit -n Clinic.Tests`
2. Добавьте ссылку на основной проект
3. CI pipeline автоматически запустит тесты

### Мониторинг:
- Логи Azure App Service доступны через Azure Portal
- Docker контейнеры можно мониторить через Docker Desktop или Azure Container Instances

### Безопасность:
- Используйте GitHub Secrets для хранения чувствительных данных
- Не коммитьте ключи подключения к БД в репозиторий