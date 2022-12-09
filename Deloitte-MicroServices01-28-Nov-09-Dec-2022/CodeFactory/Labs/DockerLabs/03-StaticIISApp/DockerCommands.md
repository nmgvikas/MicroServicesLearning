# build the docker image

docker image build --build-arg ENV_NAME=TEST --tag sriniiyer/iis-static-app:v10 .


docker run -p 9090:80 sriniiyer/iis-static-app:v10


docker push sriniiyer/iis-static-app:v10
