To launch the application, go to the solution folder.
Then build the application with the command:

> docker build -t municorntestapp .

Then start the docker container

> docker run -it --rm -p 5000:80 --name municorn_test_app municorntestapp