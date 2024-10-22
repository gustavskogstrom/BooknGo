import { BrowserRouter as Router, Route, Routes } from "react-router-dom";

import Home from "./pages/Home";
import Bookings from "./pages/Bookings";
import Availabilities from "./pages/Availabilities"
import Resources from "./pages/Resources"
import Login from "./pages/Login"

import "./assets/css/style.css";

const App = () => {
  return (
    <Router>
      <article className="page">
        <section>
          <Routes>
            <Route path="*" element={<Home />} />
            <Route path="/" element={<Home />} />
            <Route path="/Bookings" element={<Bookings />} />
            <Route path="/Availabilities" element={<Availabilities />} />
            <Route path="/Resources" element={<Resources />} />
            <Route path="/Login" element={<Login />} />
          </Routes>
        </section>
      </article>
    </Router>
  );
}

export default App;
