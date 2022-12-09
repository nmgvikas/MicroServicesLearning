# Build the image 

docker image build --tag sriniiyer/myaspnetwinapp:linux-v10 .

# Run the image as a container

docker run -d -p 9091:80 sriniiyer/myaspnetwinapp:linux-v10


# get into the container


docker container ls

docker exec -it <containerid> cmd

# push to dockerhub

docker push sriniiyer/myaspnetwinapp:linux-v10


