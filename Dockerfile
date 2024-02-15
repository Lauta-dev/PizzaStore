FROM alpine:latest
WORKDIR /cs
COPY . /cs

# Instalación de dependencias
RUN apk add --no-cache \
    wget \
    ca-certificates \
    bash \
    icu-libs \
    libstdc++ \
    libgcc \
    libc6-compat

SHELL ["/bin/bash", "-c"]

# Concesión de permisos de ejecución al script
RUN chmod +x ./dotnet-install.sh
RUN chmod +x /cs/setEnv.sh

# Ejecución del script dotnet-install.sh
RUN ./dotnet-install.sh --channel 8.0 || true

RUN ./setEnv.sh
ENV PATH="/root/.dotnet:$PATH"
RUN echo 'export PATH="/root/.dotnet:$PATH"' >> /etc/profile

WORKDIR /project
COPY ./bin/Release/net8.0/publish/ ./
CMD ["dotnet", "PizzaStore.dll"]
