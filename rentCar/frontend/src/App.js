import React, { useState, useEffect } from "react";

function App() {
  const [users, setUsers] = useState([]);
  const [newUser, setNewUser] = useState({ Name: "", Age: 0, City: "" });

  useEffect(() => {
    fetchUsers();
  }, []);

  const fetchUsers = async () => {
    const response = await fetch("/api/User/getUsers");
    const data = await response.json();
    setUsers(data);
  };

  const handleAddUser = async () => {
    const response = await fetch("/api/User/addUser", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newUser),
    });
    if (response.ok) {
      fetchUsers();
    }
  };

  const handleDeleteUser = async (id) => {
    const response = await fetch(`/api/User/deleteUser?id=${id}`, {
      method: "DELETE",
    });
    if (response.ok) {
      fetchUsers();
    }
  };

  return (
    <div>
      <h1>User Management</h1>
      <div>
        <h2>Add User</h2>
        <input
          type="text"
          placeholder="Name"
          value={newUser.Name}
          onChange={(e) => setNewUser({ ...newUser, Name: e.target.value })}
        />
        <input
          type="number"
          placeholder="Age"
          value={newUser.Age}
          onChange={(e) =>
            setNewUser({ ...newUser, Age: parseInt(e.target.value) })
          }
        />
        <input
          type="text"
          placeholder="City"
          value={newUser.City}
          onChange={(e) => setNewUser({ ...newUser, City: e.target.value })}
        />
        <button onClick={handleAddUser}>Add User</button>
      </div>
      <div>
        <h2>Users</h2>
        <ul>
          {users.map((user) => (
            <li key={user.Id}>
              {user.Name}, {user.Age}, {user.City}
              <button onClick={() => handleDeleteUser(user.Id)}>Delete</button>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}

export default App;
