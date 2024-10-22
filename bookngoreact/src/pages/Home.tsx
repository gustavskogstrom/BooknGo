import Navbar from "../components/Navbar"
let welcome = "Welcome to BooknGo!";

const Home = () => {
    return(
        <section className="welcome">
            <h1>{welcome}</h1>
            <Navbar/>
        </section>
    );
}

export default Home;