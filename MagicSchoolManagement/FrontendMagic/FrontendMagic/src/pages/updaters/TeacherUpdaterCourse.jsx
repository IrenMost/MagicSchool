import { useState } from "react";
import { useParams } from "react-router-dom";
//import "./TeacherUpdater.css";




const TypeUpdater = () => {

    const [loading, setLoading] = useState(false);
    const [updated, setUpdated] = useState(false);
    const [name, setName] = useState('');
    //const [level, setLevel] = useState('');
    const [newCourse, setNewCourse] = useState('');

    const [message, setMessage] = useState('');

    const teacherId = useParams().teacherId;




    const updateTeacher = async (e) => {
        e.preventDefault();
        setLoading(true);

        try {
            const response = await fetch(`https://localhost:7135/Teacher/updateTeacherCourse/${teacherId}`, {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ teacherId, newCourse }),
            });

            if (response.ok) {

                setUpdated(true);
                setMessage('Teacher course updated');
            } else {
                setMessage('Teacher course not updated');
            }
        } catch (error) {
            console.error('Error:', error);
            setMessage('Teacher course updated failed.');
        }
    };
    if (loading) {
        <div>Loading...  </div>
    }

    return (
        updated ? (
            <div>

                {message && <p className="message">{message}</p>}

            </div>

        ) :
            (
                <div>
                    <form className="CreateType" onSubmit={updateTeacher}>
                        <div className="control">
                            <label htmlFor="name">Type Id</label>
                            <input
                                value={typeId}
                                name="typeId"
                                id="TypeId"
                            />
                        </div>
                        <div className="control">
                            <label htmlFor="name">Description:</label>
                            <input
                                value={name}
                                onChange={(e) => setName(e.target.value)}
                                name="name"
                                id="TypeId"
                            />
                        </div>

                        <div className="buttons">
                            <button type="submit" >Update Type </button>

                        </div>
                    </form>
                    <p>majom</p>
                </div>)
    );
};

export default TypeUpdater;