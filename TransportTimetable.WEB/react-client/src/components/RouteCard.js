import React, {useState} from 'react';
import {Button, Card} from "react-bootstrap";
import useFetch from "../hooks/useFetch";
import {baseUrl} from "../constants";
import {useNavigate} from "react-router";
import TimetableModal from "./TimetableModal";

const RouteCard = ({route, stop}) => {
  const navigate = useNavigate()
  const [show, setShow] = useState(false)

  console.log(route, stop)

  return (
    <>
      <Card className={""} onClick={() => !stop && navigate("/routes/" + route.id)}>
        <Card.Body>
          <Card.Title>{route.number}</Card.Title>
          <Card.Text>{route.name}</Card.Text>
        </Card.Body>
        <Card.Footer>{stop && <Button onClick={() => setShow(true)}>Расписание</Button>}
          <Button onClick={() => navigate("/routes/" + route.id)}>Посмотреть</Button>
        </Card.Footer>
      </Card>
      {show && <TimetableModal route={route} stop={stop} show={show} setShow={setShow}/>}
    </>
  );
};

export default RouteCard;