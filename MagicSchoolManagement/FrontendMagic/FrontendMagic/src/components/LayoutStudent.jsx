import { Outlet } from "react-router-dom";

const LayoutStudent = () => {
    return (
        <div className="container">

            <main className="main">
                <Outlet />
                <p> tanulók gyertek </p>
            </main>

        </div>
    );
};

export default LayoutStudent;