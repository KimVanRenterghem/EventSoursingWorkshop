# EventEoursingWorkshop
workshop for event sourcing

This app is a tutorial to get the feeling wath you can do with event sourcing.


1. create workspase :
    1. unzip the eventstore in the tools folder
    2. unzip the curl in the tools folder
    3. add the C:\curl\ and C:\eventstore\ path to the PATH Environment Variable in Windows
    4. start eventstore
        ```cmd
        EventStore.ClusterNode.exe --db C:\eventstore\db --log C:\eventstore\logs
        ``` 
        > now you can watch your store at http://127.0.0.1:2113/
        > user admin pass changeit
2. start en stop the song thru the api and fire the events
3. create app which displays the playing song for a user
    > do this by reading only the last event of the stream (position -1)
4. start en remove the songs from a playlist thru the api and fire the events
5. create a playlist from the playlist stream
    > read the plailist stream and project it into the model
6. give top 10 list of most played songs
    > do this by reading all the user play streams and reating the number of time a song is played
    > afterwarts you cann order them and create a new play list
7. a sont choold atleast play for 20 sec to get in the list (rebuild your list)
    > change the prevuw step, drop the db and restard from position 0
8. a son witch is stopt and started on the same sec shoold be considerd not being stoped (rebuild your list)
    > change the prevuw step, drop the db and restard from position 0
9. create linked songs based on other users next 2 songs moset played
