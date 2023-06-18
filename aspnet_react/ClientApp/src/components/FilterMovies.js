import React, { useState, useEffect } from 'react';

const FilterMovies = () => {
    const [movies, setMovies] = useState([]);

/*    const dataType = 1;*/

    useEffect(() => {
        debugger;
        fetch('api/movies').then((results) => {
            return results.json();
        })
        .then(data => {
            setMovies(data);
        })
    },[])

    return(
        <main>
            {
                (movies != null) ? movies.map((movie) => <h3>{movie.title}</h3>) : <div>Loading...</div>
            }
        </main>
    )
}

export default FilterMovies;