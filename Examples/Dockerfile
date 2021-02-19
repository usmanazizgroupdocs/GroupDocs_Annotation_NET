# to build image run in PS - `docker build --pull -t annotation:examples .`
# to run tests run in PS - `docker run --rm -it -v ${PWD}:/examples/Results annotation:examples`
 
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS buid_env

# prepare
WORKDIR /examples
COPY ./*.sln ./
COPY ./GroupDocs.Annotation.Examples.CSharp/ ./GroupDocs.Annotation.Examples.CSharp/
COPY ./GroupDocs.Annotation.Examples.CSharp.Core/ ./GroupDocs.Annotation.Examples.CSharp.Core/
# end prepare

# GroupDocs.Annotation dependency - https://docs.groupdocs.com/display/annotationnet/.NET+Standard+2.0+API+Limitations
RUN dotnet add ./GroupDocs.Annotation.Examples.CSharp.Core/GroupDocs.Annotation.Examples.CSharp.Core.csproj package SkiaSharp.NativeAssets.Linux --framework netcoreapp2.1
# GroupDocs.Annotation dependency

# restore
WORKDIR /examples
RUN dotnet restore ./GroupDocs.Annotation.Examples.CSharp.Core/GroupDocs.Annotation.Examples.CSharp.Core.csproj
# end restore

## build
WORKDIR /examples
RUN dotnet publish ./GroupDocs.Annotation.Examples.CSharp.Core/GroupDocs.Annotation.Examples.CSharp.Core.csproj --no-restore --framework netcoreapp2.1 --configuration Debug -o ./../out
## end build

FROM mcr.microsoft.com/dotnet/core/runtime:2.1 

# begin GroupDocs.Annotation dependencies - https://docs.groupdocs.com/display/annotationnet/.NET+Standard+2.0+API+Limitations
RUN apt-get update && \
    DEBIAN_FRONTEND=noninteractive apt-get install -y libgdiplus && \
    DEBIAN_FRONTEND=noninteractive apt-get install -y libc6-dev

RUN apt-get update && \
    DEBIAN_FRONTEND=noninteractive apt-get install -y libfontconfig1

RUN echo "deb http://httpredir.debian.org/debian jessie main contrib" > /etc/apt/sources.list \
    && echo "deb http://security.debian.org/ jessie/updates main contrib" >> /etc/apt/sources.list \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && DEBIAN_FRONTEND=noninteractive apt-get install -y ttf-mscorefonts-installer \
    && apt-get clean \
    && apt-get autoremove -y \
    && rm -rf /var/lib/apt/lists/*
# end GroupDocs.Annotation dependencies

WORKDIR /examples
COPY --from=buid_env /examples/out .
ENTRYPOINT ["dotnet", "GroupDocs.Annotation.Examples.CSharp.Core.dll"]