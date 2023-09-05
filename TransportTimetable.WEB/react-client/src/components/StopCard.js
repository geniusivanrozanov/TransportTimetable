import React, {useState} from 'react';
import {Button, Card} from "react-bootstrap";
import {useNavigate} from "react-router";
import TimetableModal from "./TimetableModal";
import {useLocalStorage} from "../hooks/useLocalStorage";

const StopCard = ({stop, route}) => {
  const navigate = useNavigate()
  const [show, setShow] = useState(false)
  const localStorage = useLocalStorage("stops")
  const [exists, setExists] = useState(localStorage.Exsists(stop.id))

  const add = () => {
    localStorage.Add(stop.id)
    setExists(localStorage.Exsists(stop.id))
  }

  const remove = () => {
    localStorage.Remove(stop.id)
    setExists(localStorage.Exsists(stop.id))
  }

  console.log(route,stop)
  return (
    <>
      <Card className={"mb-3"}>
        <Card.Body>
          <Card.Title>{stop.name}</Card.Title>
        </Card.Body>
        <Card.Footer>
          {route && <Button onClick={() => setShow(true)}>Расписание</Button>}
          <Button
            variant={!exists ? "success" : "danger" }
            onClick={!exists ? add : remove}
          >{!exists ? "Добавить в избранное" : "Удалить из избранного"}</Button>
          <Button onClick={() => navigate("/stops/" + stop.id)}>Посмотреть</Button>
        </Card.Footer>
      </Card>
      {show && <TimetableModal route={route} stop={stop} show={show} setShow={setShow}/>}

    </>
  );
};

export default StopCard;