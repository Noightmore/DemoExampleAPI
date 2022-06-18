import React from 'react';
import {ListGroupItem} from "reactstrap";

interface user {
    uid:number
    uFirstName: string
    uLastName: string
    uGender: string
    uEmail?: string
    uBirthDate: string
}

interface Props{
    item: user;
}

const User:React.FC<Props> = ({item}) => {
    return (
            <ListGroupItem>
                {item.uFirstName}
            </ListGroupItem>
    );
}

export default User;