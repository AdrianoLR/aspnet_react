import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import FilterMovies from "./components/FilterMovies";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  }, 
  {

    path: '/filter-movies',
    element: <FilterMovies />
  }
];

export default AppRoutes;
