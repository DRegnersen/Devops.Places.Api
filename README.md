# Places API

1. Make sure that the `places-api-base` and `places-api-publish` images have been built

    ```shell
    docker build -t places-api-base -f Dockerfile.base .
    ```

    ```shell
    docker build -t places-api-publish -f Dockerfile.build .
    ```

2. To start application

    ```shell
    docker-compose up -d
    ```

    `appsettings.json` will be mounted as an external volume


3. Swagger will be available on http://localhost:8080/swagger/index.html