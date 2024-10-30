//import { DataContext } from "../components/LayOut";
//import { useContext } from "react";
//import "./HomePage.css";
import Navbar from "../components/Navbar"

export default function HomePage() {

    //const { globalData } = useContext(DataContext);
    //console.log(globalData);

    return (
        <div className="homepage">
        <Navbar />
            <img src="wand.png" alt="logo" className="header-logo" />
            <header className="header">
                <h1 className="header-title">
                    Hello {/*{globalData && globalData.username}*/} user!


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