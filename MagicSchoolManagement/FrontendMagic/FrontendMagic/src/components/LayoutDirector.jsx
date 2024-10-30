import { Outlet } from "react-router-dom";

const LayoutDirector = () => {
    return (
        <div className="container">

            <main className="main">
                <Outlet />
                <p> welcome mr Dumbledore </p>
            </main>

        </div>
    );
};

export default LayoutDirector;