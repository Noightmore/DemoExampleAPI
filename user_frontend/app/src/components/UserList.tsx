import React from 'react';
import {ListGroup} from "reactstrap";
import User from './User';

interface user {
    uid:number
    uFirstName: string
    uLastName: string
    uGender: string
    uEmail?: string
    uBirthDate: string
}

interface Props{
    items: user[]
}

const UserList: React.FC<Props> = ({items}) => {
    return (
            <ListGroup>
                {items.map((item, index) => (<User key={index} item={item} />))}
            </ListGroup>
    );
}

export default UserList;