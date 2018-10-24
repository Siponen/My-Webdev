<!doctype html>
<html>
    <head></head>
    <body>
        <h1>Skills:</h1>
        <table>
            <tr>
                <th>Id</th>
                <th>Skill</th>
                <th>Rating</th>
            </tr>

            @foreach($skills as $skill)
            <tr>
                <td>{{$skill->id}}</td>
                <td>{{$skill->title}}</td>
                <td>{{$skill->rating}}</td>
            </tr>
            @endforeach
        </table>
    </body>
</html>
