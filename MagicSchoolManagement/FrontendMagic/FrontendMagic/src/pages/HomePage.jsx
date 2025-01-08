
//import "./HomePage.css";
import Navbar from "../components/Navbar"


export default function HomePage() {

    

    return (
        <div className="homepage">
        <Navbar />
            <img src="wand.png" alt="logo" className="header-logo" />
            <header className="header">
                <h1 className="header-title">
                    Hello!


                </h1>
                <h1>Magic School Management</h1>
                <h2 className="header-subtitle">Let the adventure begin!</h2>
                <aside className="quote">
                    <i>Alohomora</i>
                </aside>
            </header>
        </div>
    );
}