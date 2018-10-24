<!doctype html>
<html>
    <head>
    </head>
    <body>
        <h1>Create a new skill</h1>
        <form action="{{url('skills')}}" method="post">
            @csrf
            <div>
                <label for="title">Title:</label>
                <input type="text" id="title" name="title" />
            </div>
            <div>
                <label for="rating">Rating:</label>
                <input type="text" id="rating" name="rating" />
            </div>
            <div class=button>
                <button type="submit">Submit</button>
            </div>
        </form>
    </body>
</html>