# Build the image 

docker image build --tag sriniiyer/mywinconsoleapp:win-v10 .

# Run the image as a container

docker run sriniiyer/mywinconsoleapp:win-v10


# get into the container


docker container ls

docker exec -it <containerid> cmd

# push to dockerhub

docker push sriniiyer/mywinconsoleapp:win-v10


