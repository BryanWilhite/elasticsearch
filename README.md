# elasticsearch

## my personal notes on [Elasticsearch](https://www.elastic.co/), a Java thing consumed from a .NET context

>Elasticsearch is a highly scalable open-source full-text search and analytics engine. It allows you to store, search, and analyze big volumes of data quickly and in near real time. It is generally used as the underlying engine/technology that powers applications that have complex search features and requirements. [[docs](https://www.elastic.co/guide/en/elasticsearch/reference/current/getting-started.html)]

## Windows install, Chocolatey flavored

Install Chocolatey [package](https://chocolatey.org/packages/jdk8), `jdk8` and make sure `JAVA_HOME` is correct. Based on what is on the [downloads](https://www.elastic.co/downloads/elasticsearch) page as of this writing, download the Elasticsearch Zip and extract:

```ps1
Invoke-WebRequest -Uri https://artifacts.elastic.co/downloads/elasticsearch/elasticsearch-6.6.0.zip
```

Add `elasticsearch-6.6.0/bin` to `PATH` and run `elasticsearch`. By the current convention, the server should be at `http://localhost:9200/`:

```json
{
    "name": "_RzHa2s",
    "cluster_name": "elasticsearch",
    "cluster_uuid": "Qjz1mRRIS9uDLxtRK776Ug",
    "version": {
        "number": "6.6.0",
        "build_flavor": "default",
        "build_type": "zip",
        "build_hash": "a9861f4",
        "build_date": "2019-01-24T11:27:09.439740Z",
        "build_snapshot": false,
        "lucene_version": "7.6.0",
        "minimum_wire_compatibility_version": "5.6.0",
        "minimum_index_compatibility_version": "5.0.0"
    },
    "tagline": "You Know, for Search"
}
```

## Elasticsearch is explored through tests

The [Getting Started](https://www.elastic.co/guide/en/elasticsearch/reference/current/getting-started.html) section of the Elasticsearch documentation is the guide that produces the [tests](ElasticSearch.Tests) in this repo. Here is a rough sketch of the order of tests:

1. `GetServerInfo_Test` [[GitHub](https://github.com/BryanWilhite/elasticsearch/blob/master/ElasticSearch.Tests/ElasticSearchTests._.cs#L25)]: verifies the installation
2. `GetServerHealth_Test` [[GitHub](https://github.com/BryanWilhite/elasticsearch/blob/master/ElasticSearch.Tests/ElasticSearchTests._cat.cs#L43)]: displays the status of the health of the installation
3. `GetServerClusterNodes_Test` [[GitHub](https://github.com/BryanWilhite/elasticsearch/blob/master/ElasticSearch.Tests/ElasticSearchTests._cat.cs#L21)]: shows the status of the default cluster node of the installation
4. `GetServerIndices_Test` [[GitHub](https://github.com/BryanWilhite/elasticsearch/blob/master/ElasticSearch.Tests/ElasticSearchTests._cat.cs#L65)]: lists the indices of the node (should return none after install)
5. `PutCustomerInNewIndex_Test` [[GitHub](https://github.com/BryanWilhite/elasticsearch/blob/master/ElasticSearch.Tests/ElasticSearchTests._index.cs#L193)]: PUTs (inserts) a new document into an index, generated automatically

Most of the tests come with comments that go into detail (beyond the official documentation) and refer to any dependencies on other tests.

@[BryanWilhite](https://twitter.com/BryanWilhite)