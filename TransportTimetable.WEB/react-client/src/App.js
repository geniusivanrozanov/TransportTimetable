import Header from "./components/Header";
import {BrowserRouter, Routes as BRoutes, Route as BRoute, Navigate} from "react-router-dom";
import Stops from "./pages/Stops";
import BuildSchema from "./pages/BuildSchema";
import Routes from "./pages/Routes";
import Stop from "./pages/Stop";
import Route from "./pages/Route";

function App() {
  return (
    <>
      <Header></Header>
      <BrowserRouter>
        <BRoutes>
          <BRoute element={<Navigate to={"/routes"}></Navigate>} path={"/"}/>
          <BRoute element={<Stops />} path={"/stops"}/>
          <BRoute element={<Stop />} path={"stops/:id"}/>
          <BRoute element={<BuildSchema />} path={"/build-schema"}/>
          <BRoute element={<Routes />} path={"/routes"}/>
          <BRoute element={<Route />} path={"routes/:id"}/>
        </BRoutes>
      </BrowserRouter>
    </>
  );
}

export default App;
