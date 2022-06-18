import React from 'react';
import {useState, useEffect, useCallback} from "react";
import {Alert, Spinner} from "reactstrap";
import axios from "axios";
import LoadAllUsersButton from './LoadAllUsersButton';
import UserList from "./UserList";



const Users: React.FC = () => {

    let debug:any = require('debug');

    debug.enable('axios');

    const [items, setItems] = useState([]);
    const [error, setError] = useState(false);
    const [isLoading, setIsLoading] = useState(false);
    useEffect(() => {
        setIsLoading(true);
        axios.get("http://localhost:5215/Users")
            .then(response => {
                console.log(response.data);
                setItems(response.data);
                setError(false);
            })
            .catch(error => {
                console.log(error);
                setError(true);
                setItems([]);
            })
            .then(()=>{
                setIsLoading(false);
            })
    },[]);

    if (error)
    {
        return <Alert color="danger">There was an error.</Alert>
    }
    else if (isLoading)
    {
        return <Spinner color="success" />
    }
    else if (items)
    {
        return (
            <div className="Users">
                <UserList items={items}/>
            </div>
        );
    }
    else
    {
        return <Spinner color="primary" />;
    }
}


export default Users;