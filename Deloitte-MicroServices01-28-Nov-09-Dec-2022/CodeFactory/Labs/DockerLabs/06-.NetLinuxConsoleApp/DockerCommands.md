# Build the image 

docker image build --tag sriniiyer/mywinconsoleapp:linux-v10 .

# Run the image as a container

docker run sriniiyer/mywinconsoleapp:linux-v10


# get into the container


docker container ls

docker exec -it <containerid> cmd

# push to dockerhub

docker push sriniiyer/mywinconsoleapp:linux-v10


