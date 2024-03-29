# Event Sourcing Workshop
workshop for event sourcing

This app is a tutorial to get the feeling what you can do with event sourcing.


1. create workspace :
    1. unzip the event store in the tools folder
    2. unzip the curl in the tools folder
    3. add the C:\curl\ and C:\eventstore\ path to the PATH Environment Variable in Windows
    4. start event store
        ```cmd
        EventStore.ClusterNode.exe --db C:\eventstore\db --log C:\eventstore\logs --run-projections=all --start-standard-projections=true
        ``` 
        > now you can watch your store at http://127.0.0.1:2113/
        > user: `admin` pass: `changeit`
2. start and stop the song through the api and fire the events
    > look in the web tool at the events 
3. create app which displays the playing song for a user
    > do this by reading only the last event of the stream (position -1)
    ```csharp
    var eveTask = connection.ReadEventAsync(stream, -1, true);
    var eve = eveTask.Result;

    var ev = eve.Event?.Event;
    if (ev != null)
    {
        //event type validation
        var json = Encoding.UTF8.GetString(ev.Data);
        var songStart = JsonConvert.DeserializeObject<SongPlayingStarted>(json);
    }
    ```
4. add and remove the songs from a playlist through the api and fire the events
5. create a playlist from the playlist stream
    > read the playlist stream and project it into the model

    > update projection $by_category set - to _
    >create new projection with the following script
    ```js
    fromCategory('playlist')
    .foreachStream()
    .when({
        PlayListCreated: function(state, ev){
        linkTo('playlist', ev)         
        }      
    });
    ```
    > now all PlayListCreated events are linked to the stream Playlist
    > !! for this to work all streams should be lower case and have a `-` between the streamname-id
    ```csharp
    public delegate IProjector ProjectorFactory();
    ```
    ```csharp
    
        public async void Start(string streamName, ProjectorFactory projectorFactory)
        {
            var projector = projectorFactory();

            long pos = 0;
            while (true)
            {
                var slice = await _connection.ReadStreamEventsForwardAsync(streamName, pos, 5, true);
                if (pos < slice.NextEventNumber)
                {
                    pos = slice.NextEventNumber;

                    //create a stream for all the linked streames
                    foreach (var e in slice.Events
                        .Where(e => e.Link?.EventType == "$>"))
                    {
                        Start(e.Event.EventStreamId, projectorFactory);
                    }

                    var nonlinks = slice.Events
                        .Where(e => e.Link == null)
                        .ToList();

                    projector.Project(nonlinks);

                }
                else
                {
                    await Task.Delay(100);
                }
            }
    ```
6. give top 10 list of most played songs
    > do this by reading all the user play streams and rating the number of times a song is played
    > afterwards you can order them and create a new play list
    >create new projection with the following script
    ```js
    fromCategory('usersong')
    .foreachStream()
    .when({
        $any: function(state, ev){
        linkTo('songs', ev)         
        }      
    });
    ```
7. a song should at least play for 20 sec to get in the list (rebuild your list)
    > change the preview step, drop the db and restart from position 0
8. a song which is stopped and started in the same second should be considered not stopped (rebuild your list)
    > change the preview step, drop the db and restart from position 0
9. create linked songs based on other users next 2 songs most played
