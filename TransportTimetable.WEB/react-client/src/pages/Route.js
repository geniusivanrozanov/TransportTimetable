import React from 'react';
import {Card, Container} from "react-bootstrap";
import {useParams} from "react-router";
import useFetch from "../hooks/useFetch";
import {baseUrl} from "../constants";
import StopCard from "../components/StopCard";

const Route = () => {
  const {id} = useParams()
  const {data: route} = useFetch(baseUrl + "/api/routes/" + id)


  return (
    <>
      <Container className={"d-flex justify-content-center align-items-center"}>
        {
          route &&
          <Card>
            <Card.Header>{route.transportType} №{route.number} {route.name}</Card.Header>
            <Card.Body>{route.stops.map(stop => <StopCard stop={stop} route={route}></StopCard>)}</Card.Body>
          </Card>
        }
      </Container>
    </>
  );
};

export default Route;