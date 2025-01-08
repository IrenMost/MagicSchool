import { Outlet } from "react-router-dom";

const LayoutDirector = () => {
    return (
        <div className="container">

            <main className="main">
                <p> welcome mr Dumbledore </p>
                <Outlet />
                
            </main>

        </div>
    );
};

export default LayoutDirector;