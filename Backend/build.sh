#!/bin/bash
# /bin/bash build.sh <project> <branch> [Dockerfile]
project=""                              # project-name
tag=""                                  # docker image tag (branch)
Dockerfile="Dockerfile" # Dockerfile
registry=""
registry_user="tupk"
registry_password="phungkhactu"
# Check parameter project and branch
if [ ! -z "$2" ]; then
        project="$1"
        if [ $2 == "master" ]; then
        tag="latest"
        elif [ $2 == "pro" ] || [ $2 == "prod" ]  || [ $2 == "release" ]; then
                        tag="stable"
        else
                tag=$2
        fi
else
        echo "Can not build empty tag for project $2"
        exit 1
fi
# Check parameter Dockerfile
if [ ! -z "$3" ]; then
        Dockerfile="$3"
fi
# Check Dockerfile exits
if [ -f "./Dockerfile" ]; then
        echo "$(date +'%d-%m-%Y %H:%M:%S') [$HOSTNAME] Build $Dockerfile"
        DOCKER_BUILDKIT=1 docker build -f $Dockerfile -t $registry_user/$project:$tag .
else
        echo "$Dockerfile not found!"
        exit 1
fi
retVal=$?
if [ $retVal -gt 0 ]; then
    echo "Build failed - exit code: $retVal"
    exit 1
fi
# Tag and push to docker registry server
docker login $registry -u $registry_user -p $registry_password
docker push $registry_user/$project:$tag

echo "$(date +'%d-%m-%Y %H:%M:%S') [$HOSTNAME] End build"
